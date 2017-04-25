using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Ejercicio2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Ingrese el Nombre de la Ciudad:");

            string ciudad = Convert.ToString(Console.ReadLine());

            WebRequest req = WebRequest.Create("https://maps.googleapis.com/maps/api/geocode/json?address=" + ciudad +"&key=AIzaSyDgwOpkxGZpV1tYSmh6L3ZEflt6WfnGeCw");

            WebResponse respuesta = req.GetResponse();

            Stream stream = respuesta.GetResponseStream();

            StreamReader sr = new StreamReader(stream);

            JObject data = JObject.Parse(sr.ReadToEnd());

            string address = (string)data["results"][0]["address_components"][2]["long_name"];

            Console.WriteLine("Esa ciudad se encuentra en el pais:");

            Console.WriteLine(address);

            Console.ReadKey();
        }
    }
}
