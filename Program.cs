using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CrudEstudiantesGitFlow
{
    public class Estudiante
    {
        public string Matricula { get; set; } = "";
        public string Nombre { get; set; } = "";
        public string Carrera { get; set; } = "";
    }

    class Program
    {
        static string archivo = "estudiantes.json";

        static List<Estudiante> CargarDatos()
        {
            if (!File.Exists(archivo)) return new List<Estudiante>();
            string json = File.ReadAllText(archivo);
            return JsonSerializer.Deserialize<List<Estudiante>>(json) ?? new List<Estudiante>();
        }

        static void GuardarDatos(List<Estudiante> lista)
        {
            string json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(archivo, json);
        }

        static void CrearEstudiante()
        {
            var lista = CargarDatos();
            Console.Write("Matricula: ");
            string mat = Console.ReadLine() ?? "";
            Console.Write("Nombre: ");
            string nom = Console.ReadLine() ?? "";
            Console.Write("Carrera: ");
            string car = Console.ReadLine() ?? "";

            lista.Add(new Estudiante { Matricula = mat, Nombre = nom, Carrera = car });
            GuardarDatos(lista);
            Console.WriteLine("Estudiante guardado correctamente.");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Estructura base y crear estudiante listos.");
        }
    }
}
