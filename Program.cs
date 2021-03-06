using System.Net;
using System.Text.Json;

namespace TrabajoPractico10{
    class Program{

    static void Main(string[] args){
        Punto1();
        Punto2();
    }

    static void Punto1(){
        string url = $"https://age-of-empires-2-api.herokuapp.com/api/v1/civilizations";
        var request = (HttpWebRequest)WebRequest.Create(url);
        RootCiv listaCivilizaciones;
        request.Method = "GET";
        request.ContentType = "application/json";
        request.Accept = "applicacion/json";

        try{
            WebResponse respuesta = request.GetResponse();
            Stream strReader = respuesta.GetResponseStream();
            StreamReader objReader = new StreamReader(strReader);
            string responseBody = objReader.ReadToEnd();
            listaCivilizaciones = JsonSerializer.Deserialize<RootCiv>(responseBody);

            foreach(var i in listaCivilizaciones.Civilizations){
                Console.WriteLine($"Nombre: {i.Name}");
                Console.WriteLine($"Expansión: {i.Expansion}\n");
            }

            Console.WriteLine("Mostrando las características de la primera civilización:");

            Console.WriteLine($"ID: {listaCivilizaciones.Civilizations[0].Id}");
            Console.WriteLine($"Nombre: {listaCivilizaciones.Civilizations[0].Name}");
            Console.WriteLine($"Expansión: {listaCivilizaciones.Civilizations[0].Expansion}");
            Console.WriteLine($"Bonus de equipo: {listaCivilizaciones.Civilizations[0].TeamBonus}");
            Console.WriteLine($"Bonus de civilización:");
            foreach(string str in listaCivilizaciones.Civilizations[0].CivilizationBonus){
                Console.WriteLine(str);
            }
        }
        catch(WebException error){
            Console.WriteLine("Ha ocurrido un problema");
        }
    }

    static void Punto2(){
        string url = $"https://age-of-empires-2-api.herokuapp.com/api/v1/structures";
        var request = (HttpWebRequest)WebRequest.Create(url);
        RootStr listaEstructuras;
        request.Method = "GET";
        request.ContentType = "application/json";
        request.Accept = "applicacion/json";

        try{
            WebResponse respuesta = request.GetResponse();
            Stream strReader = respuesta.GetResponseStream();
            StreamReader objReader = new StreamReader(strReader);
            string responseBody = objReader.ReadToEnd();
            listaEstructuras = JsonSerializer.Deserialize<RootStr>(responseBody);

            Console.WriteLine("Mostrando las diferentes estructuras:");

            foreach(Structure i in listaEstructuras.Structures){
                Console.WriteLine($"Nombre: {i.Name}");
                Console.WriteLine($"Expansión: {i.Expansion}\n");
                Console.WriteLine($"Año: {i.Age}\n");
            }

            Console.WriteLine("Mostrando las características de la primera estructura:");

            Console.WriteLine($"ID: {listaEstructuras.Structures[0].Id}");
            Console.WriteLine($"Nombre: {listaEstructuras.Structures[0].Name}");
            Console.WriteLine($"Expansión: {listaEstructuras.Structures[0].Expansion}");
            Console.WriteLine($"Año: {listaEstructuras.Structures[0].Age}");
            Console.WriteLine($"Costo:");
            Console.WriteLine($"Madera: {listaEstructuras.Structures[0].Cost.Wood}");
            Console.WriteLine($"Piedra: {listaEstructuras.Structures[0].Cost.Stone}");
            Console.WriteLine($"Oro: {listaEstructuras.Structures[0].Cost.Gold}");
            Console.WriteLine($"Resistencia: {listaEstructuras.Structures[0].HitPoints}");
            Console.WriteLine($"Especial:");
            foreach(string str in listaEstructuras.Structures[0].Special){
                Console.WriteLine(str);
            }
        }
        catch(WebException error){
            Console.WriteLine("Ha ocurrido un problema");
        }
    }
}
}