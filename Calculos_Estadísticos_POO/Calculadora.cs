using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Calculos_Estadísticos_POO
{
    public class Calculadora
    {
        public double ListaNumeros { get; set; }
        public double Media { get; set; }
        public double Mediana { get; set; }
        public double Moda { get; set; }
        public double DesviacionEstandar { get; set; }


        public Calculadora(double numeros, double media, double mediana, double moda, double desviacionEstandar)
        {
            ListaNumeros = numeros;
            Media = media;
            Mediana = mediana;
            Moda = moda;
            DesviacionEstandar = desviacionEstandar;

        }
    }
    public void MostrarMenu()
    {
        Console.WriteLine("Menú Cálculos Estadísticos:");
        Console.WriteLine("1. Ingresar Lista de Números");
        Console.WriteLine("2. Calcular y Mostrar Media");
        Console.WriteLine("3. Calcular y Mostrar Mediana");
        Console.WriteLine("4. Calcular y Mostrar Moda");
        Console.WriteLine("5. Calcular y Mostrar Desviación Estandar");
        Console.WriteLine("6. Volver a Ingresar números");
        Console.WriteLine("7. Salir");
        Console.Write("Selecciona una opción: ");
    }

    public List<double> ListaNumeros()
    {
        List<double> numeros = new List<double>();

        Console.Write("Ingrese la cantidad de números que desea introducir: ");
        int cantidad;
        while (true)
        {
            try
            {
                cantidad = Convert.ToInt32(Console.ReadLine());
                if (cantidad <= 0)
                {
                    Console.Write("La cantidad debe ser un número entero positivo. Inténtelo de nuevo: ");
                    continue;
                }
                break;
            }
            catch (FormatException)
            {
                Console.Write("Entrada no válida. Ingrese un número entero positivo: ");
            }
        }

        for (int i = 0; i < cantidad; i++)
        {
            double numero;
            while (true)
            {
                Console.Write($"Ingrese el número {i + 1}: ");
                try
                {
                    numero = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.Write("Entrada no válida. Ingrese un número válido: ");
                }
            }
            numeros.Add(numero);
        }

        return numeros;
    }

    static void Media(List<double> numeros)
    {
        if (numeros.Count == 0)
        {
            Console.WriteLine("No hay números ingresados.");
            return;
        }

        double suma = 0;
        foreach (var numero in numeros)
        {
            suma += numero;
        }
        double media = suma / numeros.Count;

        Console.WriteLine($"La media es: {media}");
    }

    static void Mediana(List<double> numeros)
    {
        if (numeros.Count == 0)
        {
            Console.WriteLine("No hay números ingresados.");
            return;
        }

        for (int i = 0; i < numeros.Count - 1; i++)
        {
            for (int j = 0; j < numeros.Count - 1 - i; j++)
            {
                if (numeros[j] > numeros[j + 1])
                {
                    // Intercambiar numeros[j] y numeros[j + 1]
                    double temp = numeros[j];
                    numeros[j] = numeros[j + 1];
                    numeros[j + 1] = temp;
                }
            }
        }

        int cantidadNumeros = numeros.Count;
        double mediana;

        if (cantidadNumeros % 2 == 1)
        {
            mediana = numeros[cantidadNumeros / 2];
        }
        else
        {
            mediana = (numeros[cantidadNumeros / 2 - 1] + numeros[cantidadNumeros / 2]) / 2;
        }

        Console.WriteLine($"La mediana es: {mediana}");
    }

    static void Moda(List<double> numeros)
    {
        List<double> numerosUnicos = new List<double>();
        List<double> frecuencias = new List<double>();

        foreach (var numero in numeros)
        {
            bool encontrado = false;
            for (int i = 0; i < numerosUnicos.Count; i++)
            {
                if (numerosUnicos[i] == numero)
                {
                    frecuencias[i]++;
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                numerosUnicos.Add(numero);
                frecuencias.Add(1);
            }
        }

        double maximaFrecuencia = 0;
        double moda = numerosUnicos[0];

        for (int i = 0; i < frecuencias.Count; i++)
        {
            if (frecuencias[i] > maximaFrecuencia)
            {
                maximaFrecuencia = frecuencias[i];
                moda = numerosUnicos[i];
            }
        }

        Console.WriteLine($"La moda es: {moda}");
    }

    static void DesviacionEstandar(List<double> numeros)
    {
        if (numeros.Count == 0)
        {
            Console.WriteLine("No hay números ingresados.");
            return;
        }

        double media = 0;
        double suma = 0;
        foreach (var numero in numeros)
        {
            suma += numero;
        }
        media = suma / numeros.Count;

        double formulaDesviacion = 0;
        foreach (var numero in numeros)
        {
            formulaDesviacion += Math.Abs(numero - media);
        }
        double desviacionEstandar = formulaDesviacion / numeros.Count;

        Console.WriteLine($"La desviación estándar es: {desviacionEstandar}");
    }
