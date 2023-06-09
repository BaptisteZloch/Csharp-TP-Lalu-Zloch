﻿using static Personne;
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

            var resizer = new PhotoResizer { TargetWidth = 200, TargetHeight = 200 };
            //resizer.ResizeAnImage("./img/image1.png");
            resizer.ResizeSomeImages(
                new string[] { "./img/image1.png", "./img/image2.png" },
                parallel: true
            );
            resizer.ResizeSomeImages(
                new string[] { "./img/image1.png", "./img/image2.png" },
                parallel: false
            );
            resizer.ResizeFromFolder("./img");
        }
    }
}
