using static Personne;
using Newtonsoft.Json;

namespace Sample2
{
    class Program
    {
        static void Main(string[] args)
        {
            var personne = new Personne { Nom = "John", Age = 30 };

            string json = JsonConvert.SerializeObject(personne, Formatting.Indented);

            Console.WriteLine(json);
            Console.WriteLine(personne.Hello(false));

            var resizer = new PhotoResizer();
            resizer.ResizedAnImage("./img/image1.png");
        }
    }
}
