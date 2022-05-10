// See https://aka.ms/new-console-template for more information
using KaijuApp.Data;
using KaijuApp.Domain;

namespace KaijuApp.UI
{
    class Program
    {
        private static KaijuContext _context = new();

        private static void Main(string[] args)
        {
            _context.Database.EnsureCreated();
            var kaiju = new Kaiju { Name = "Godzilla" };
            GetKaijus("Before Add:");
            AddKaiju();
            GetKaijus("After Add:");
            Console.WriteLine("Press an key...");
            Console.ReadKey();
        }


        private static void AddKaiju()
        {
            var kaiju = new Kaiju { Name = "Godzilla" };
            _context.Kaijus.Add(kaiju);
            _context.SaveChanges();
        }

        private static void GetKaijus(string text)
        {
            var kaijus = _context.Kaijus.ToList();
            Console.WriteLine($"{text}: Kaiju count is {kaijus.Count}");
            foreach (var kaiju in kaijus)
            {
                Console.WriteLine(kaiju.Name);
            }
        }
    }

}