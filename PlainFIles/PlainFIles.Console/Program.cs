using PlainFIles.Core;

Console.Write("Digite el nombre de la lista: ");
var listName = Console.ReadLine();
var manualCsv = new ManualCsvHelper();
var people = manualCsv.ReadCsv($"{listName}.csv");
var option = string.Empty;

do
{
    option = MyMenu();
    switch(option)
    {
        case "1":
            Console.Write("Digite el nombre: ");
            var name = Console.ReadLine();
            Console.Write("Digite el apellido: ");
            var lastName = Console.ReadLine();
            Console.Write("Digite la edad: ");
            var age = Console.ReadLine();
            people.Add(new string[] { name ?? string.Empty, lastName ?? string.Empty, age ?? string.Empty });
            break;
        case "2":
            Console.WriteLine("Lista de personas:");
            Console.WriteLine("Nombres|Apellido|Edad");
            foreach (var person in people)
            {
                Console.WriteLine($"Nombre: {person[0]}|Apellido: {person[1]}|Edad: {person[2]}");
            }
            break;
        case "3":
            SavedFile(people, listName);
            Console.WriteLine("Archivo guardado correctamente.");
            break;
        case "0":
            Console.WriteLine("Saliendo del programa...");
            break;
        default:
            Console.WriteLine("Opción no válida. Intente de nuevo.");
            break;
    }


} while (option != "0");

string MyMenu()
{
    Console.WriteLine("Seleccione una opción:");
    Console.WriteLine("1. Adicionar");
    Console.WriteLine("2. Mostrar");
    Console.WriteLine("3. Grabar");
    Console.WriteLine("4. Eliminar");
    Console.WriteLine("5. Ordenar");
    Console.WriteLine("0. Salir");
    Console.Write("Seleccione una Opción: ");
    return Console.ReadLine() ?? string.Empty;
}

SavedFile(people, listName);

void SavedFile(List<string[]> people, string? listName)
{
    manualCsv.WriteCsv($"{listName}.csv", people);
}