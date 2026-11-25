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

        static void Main(string[] args)
        {
            Console.WriteLine("Estructura base del CRUD inicializada.");
        }
    }
}
