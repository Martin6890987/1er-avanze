// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ProyectoBinario
{
    [Serializable]
    class Entidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Nombre}, Descripción: {Descripcion}";
        }
    }

    class ManejadorEntidades
    {
        private List<Entidad> entidades = new List<Entidad>();

        public void Alta(int id, string nombre, string descripcion)
        {
            Entidad entidad = new Entidad() { Id = id, Nombre = nombre, Descripcion = descripcion };
            entidades.Add(entidad);
            Console.WriteLine("La entidad ha sido dada de alta.");
        }

        public void Baja(int id)
        {
            Entidad entidad = entidades.Find(e => e.Id == id);
            if (entidad != null)
            {
                entidades.Remove(entidad);
                Console.WriteLine("La entidad ha sido dada de baja.");
            }
            else
            {
                Console.WriteLine("No se encontró ninguna entidad con ese ID.");
            }
        }

        public void Modificar(int id, string nombre, string descripcion)
        {
            Entidad entidad = entidades.Find(e => e.Id == id);
            if (entidad != null)
            {
                entidad.Nombre = nombre;
                entidad.Descripcion = descripcion;
                Console.WriteLine("La entidad ha sido modificada.");
            }
            else
            {
                Console.WriteLine("No se encontró ninguna entidad con ese ID.");
            }
        }

        public void Buscar(int id)
        {
            Entidad entidad = entidades.Find(e => e.Id == id);
            if (entidad != null)
            {
                Console.WriteLine(entidad.ToString());
            }
            else
            {
                Console.WriteLine("No se encontró ninguna entidad con ese ID.");
            }
        }

        public void Guardar(string archivo)
        {
            FileStream fs = new FileStream(archivo, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, entidades);
            fs.Close();
            Console.WriteLine("Las entidades han sido guardadas en el archivo binario.");
        }

        public void Cargar(string archivo)
        {
            if (File.Exists(archivo))
            {
                FileStream fs = new FileStream(archivo, FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                entidades = (List<Entidad>)formatter.Deserialize(fs);
                fs.Close();
                Console.WriteLine("Las entidades han sido cargadas del archivo binario.");
            }
            else
            {
                Console.WriteLine("El archivo no existe.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ManejadorEntidades manejador = new ManejadorEntidades();

            while (true)
            {
                Console.WriteLine("\nSeleccione una opción:");
                Console.WriteLine("1. Dar de alta una entidad");
                Console.WriteLine("2. Dar de baja una entidad");
                Console.WriteLine("3. Modificar una entidad");
                Console.WriteLine("4. Buscar una entidad");
                Console.WriteLine("5. Guardar las entidades en un archivo");
            }
        }
    }
}
