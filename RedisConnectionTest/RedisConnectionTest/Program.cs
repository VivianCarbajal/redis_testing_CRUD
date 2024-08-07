using RedisConnectionTest;

class Program
{
    static void Main(string[] args)
    {
        var program = new Program();

        Console.WriteLine("Elige una opcion:");
        Console.WriteLine("1. Salva datos a cache");
        Console.WriteLine("2. Lee datos del cache");
        Console.WriteLine("3. Borra datos del cache");
        Console.WriteLine("4. Actualiza datos en el cache");
        var choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.Write("Ingresa un key: ");
            var key = Console.ReadLine();
            Console.Write("Ingresa un value: ");
            var value = Console.ReadLine();

            program.SaveData(key, value);
            Console.WriteLine("Datos salvados exitosamente.");
        }
        else if (choice == "2")
        {
            Console.Write("Ingresa un key: ");
            var key = Console.ReadLine();

            program.ReadData(key);
        }
        else if (choice == "3")
        {
            Console.Write("Ingresa un key: ");
            var key = Console.ReadLine();

            program.DeleteData(key);
            Console.WriteLine("Datos borrados exitosamente.");
        }
        else if (choice == "4")
        {
            Console.Write("Ingresa un key: ");
            var key = Console.ReadLine();
            Console.Write("Ingresa nuevo valor: ");
            var value = Console.ReadLine();

            program.UpdateData(key, value);
            Console.WriteLine("Datos actualizados exitosamente.");
        }
        else
        {
            Console.WriteLine("Opcion invalida.");
        }

        Console.ReadLine();
    }

    public void ReadData(string key)
    {
        var cache = RedisConnectorHelper.Connection.GetDatabase();
        var value = cache.StringGet(key);
        Console.WriteLine($"Key={key}, Valor={value}");
    }

    public void SaveData(string key, string value)
    {
        var cache = RedisConnectorHelper.Connection.GetDatabase();
        cache.StringSet(key, value);
    }

    public void DeleteData(string key)
    {
        var cache = RedisConnectorHelper.Connection.GetDatabase();
        cache.KeyDelete(key);
    }

    public void UpdateData(string key, string newValue)
    {
        var cache = RedisConnectorHelper.Connection.GetDatabase();
        cache.StringSet(key, newValue);
    }
}