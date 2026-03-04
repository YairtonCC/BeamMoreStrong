

namespace BeamMoreStrong.Frontend
{
    
        class Program
        {
            static void Main(string[] args)
            {
                Console.Write("Ingrese la viga: ");
                string input = Console.ReadLine()!;  
                Class1 validador = new Class1(input);
                Console.WriteLine(validador.CheckSupport());
            }
        }
    }

