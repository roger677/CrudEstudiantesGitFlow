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

        static void ListarEstudiantes()
        {
            var lista = CargarDatos();
            if (lista.Count == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }
            foreach (var est in lista)
            {
                Console.WriteLine($"Matricula: {est.Matricula} | Nombre: {est.Nombre} | Carrera: {est.Carrera}");
            }
        }

        static void ActualizarEstudiante()
        {
            var lista = CargarDatos();
            Console.Write("Matricula del estudiante a actualizar: ");
            string mat = Console.ReadLine() ?? "";

            var est = lista.Find(e => e.Matricula == mat);
            if (est == null)
            {
                Console.WriteLine("Estudiante no encontrado.");
                return;
            }

            Console.Write("Nuevo nombre: ");
            est.Nombre = Console.ReadLine() ?? "";
            Console.Write("Nueva carrera: ");
            est.Carrera = Console.ReadLine() ?? "";

            GuardarDatos(lista);
            Console.WriteLine("Estudiante actualizado.");
        }

        static void EliminarEstudiante()
        {
            var lista = CargarDatos();
            Console.Write("Matricula del estudiante a eliminar: ");
            string mat = Console.ReadLine() ?? "";

            int eliminados = lista.RemoveAll(e => e.Matricula == mat);
            if (eliminados == 0)
            {
                Console.WriteLine("Estudiante no encontrado.");
                return;
            }

            GuardarDatos(lista);
            Console.WriteLine("Estudiante eliminado.");
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n--- CRUD DE ESTUDIANTES ---");
                Console.WriteLine("1. Crear estudiante");
                Console.WriteLine("2. Listar estudiantes");
                Console.WriteLine("3. Actualizar estudiante");
                Console.WriteLine("4. Eliminar estudiante");
                Console.WriteLine("5. Salir");
                Console.Write("Elige una opcion: ");
                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1": CrearEstudiante(); break;
                    case "2": ListarEstudiantes(); break;
                    case "3": ActualizarEstudiante(); break;
                    case "4": EliminarEstudiante(); break;
                    case "5": return;
                    default: Console.WriteLine("Opcion no valida."); break;
                }
            }
        }
    }
}
