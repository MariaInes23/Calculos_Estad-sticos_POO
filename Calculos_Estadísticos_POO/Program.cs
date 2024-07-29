List<double> numeros = new List<double>();

while (true)
{
    Console.Clear();
    MostrarMenu();
    int opcion = Convert.ToInt32(Console.ReadLine());
    try
    {
        switch (opcion)
        {
            case 1:
                numeros = ListaNumeros();
                break;
            case 2:
                Media(numeros);
                break;
            case 3:
                Mediana(numeros);
                break;
            case 4:
                Moda(numeros);
                break;
            case 5:
                DesviacionEstandar(numeros);
                break;
            case 6:
                ListaNumeros();
                break;
            case 7:
                Console.WriteLine("Saliendo...");
                return;
            default:
                Console.WriteLine("Opción no válida, intenta de nuevo.");
                break;
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Entrada no válida. Asegúrese de ingresar un número entero.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error inesperado: {ex.Message}");
    }
    Console.WriteLine("\nPresiona Enter para continuar...");
    Console.ReadLine();
}
