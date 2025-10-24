using PlainFIles;
using System.ComponentModel.Design;

var textFIle = new SimpleTextFile("data.txt");
var lines = textFIle.ReadAllLines().ToList();
var opc = string.Empty;

do
{
    opc = Menu();
    switch (opc)
    {
        case "1":
            Console.WriteLine("Contenido del archivo:");
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            break;
        case "2":
            Console.Write("Ingrese la linea a agregar: ");
            var newLine = Console.ReadLine() ?? string.Empty;
            lines.Add(newLine);
            break;
        case "3":
            textFIle.WritteAllLines(lines);
            Console.WriteLine("Archivo guardado.");
            break;
        case "0":
            textFIle.WritteAllLines(lines);
            Console.WriteLine("Saliendo...");
            break;
        default:
            Console.WriteLine("Opcion no valida.");
            break;
    }
} while (opc != "0");

string Menu()
{
    Console.WriteLine("1. Mostrar");
    Console.WriteLine("2. Adicionar");
    Console.WriteLine("3. Guardar");
    Console.WriteLine("0. Sair");
    Console.Write("su opcion es: ");
    return Console.ReadLine() ?? string.Empty;
}