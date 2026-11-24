using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

class Program
{
    static double Media(List<double> datos)
    {
        return datos.Sum() / datos.Count;
    }

    static double Varianza(List<double> datos)
    {
        double media = Media(datos);
        double suma = 0;
        foreach (double x in datos)
            suma += Math.Pow(x - media, 2);
        return suma / (datos.Count - 1);
    }

    static double DesviacionEstandar(List<double> datos)
    {
        return Math.Sqrt(Varianza(datos));
    }

    static void Main()
    {
        Console.WriteLine("Escribe los números separados por espacios (usa punto decimal):");
        string linea = Console.ReadLine() ?? "";
        string[] partes = linea.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var datos = new List<double>();
        foreach (string p in partes)
        {
            if (!double.TryParse(p, NumberStyles.Float, CultureInfo.InvariantCulture, out double valor))
            {
                Console.WriteLine($"Error: '{p}' no es un número válido.");
                return;
            }
            datos.Add(valor);
        }

        if (datos.Count < 2)
        {
            Console.WriteLine("Error: se necesitan al menos 2 números.");
            return;
        }

        Console.WriteLine($"Cantidad:             {datos.Count}");
        Console.WriteLine($"Suma:                 {datos.Sum():F2}");
        Console.WriteLine($"Mínimo:               {datos.Min():F2}");
        Console.WriteLine($"Máximo:               {datos.Max():F2}");
        Console.WriteLine($"Media:                {Media(datos):F2}");
        Console.WriteLine($"Varianza:             {Varianza(datos):F2}");
        Console.WriteLine($"Desviación estándar:  {DesviacionEstandar(datos):F2}");
    }
}
