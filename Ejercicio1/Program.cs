using System;
using System.Net;
using System.IO;

using Newtonsoft.Json.Linq;

namespace Ejercicio1
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese el titulo de la pelicula:");

            string pelicula = Convert.ToString(Console.ReadLine());

            WebRequest req = WebRequest.Create("http://www.omdbapi.com/?t="+pelicula);

            WebResponse respuesta = req.GetResponse();

            Stream stream = respuesta.GetResponseStream();

            StreamReader sr = new StreamReader(stream);

            JObject data = JObject.Parse(sr.ReadToEnd());

            string titulo = (string)data["Year"];

            Console.WriteLine("El año de salida de esa pelicula es:");

            Console.WriteLine(titulo);

            Console.ReadKey();
        }

    }
}
