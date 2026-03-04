using System;

public class Ejercicio28
{
    public static void Main(string[] args)
    {
        Console.Write("Ingrese la viga: ");
        string viga = Console.ReadLine();

        if (EsValida(viga))
        {
            if (SoportaPeso(viga))
            {
                Console.WriteLine("La viga soporta el peso!");
            }
            else
            {
                Console.WriteLine("La viga NO soporta el peso!");
            }
        }
        else
        {
            Console.WriteLine("La viga está mal construida!");
        }
    }

    public static bool EsValida(string viga)
    {
        string baseViga = viga.Substring(0, 1);
        if (!(baseViga == "%" || baseViga == "&" || baseViga == "#"))
        {
            return false;
        }

        int contConex = 0;
        for (int i = 1; i < viga.Length; i++)
        {
            string pieza = viga.Substring(i, 1);

            if (!(pieza == "=" || pieza == "*"))
            {
                return false;
            }

            if (pieza == "*")
            {
                contConex++;
            }
            else
            {
                contConex = 0;
            }

            if (contConex >= 2)
            {
                return false;
            }
        }

        return true;
    }

    public static bool SoportaPeso(string viga)
    {
        string baseViga = viga.Substring(0, 1);

        int pesoTotal = 0;
        int secuencia = 0;

        for (int i = 1; i < viga.Length; i++)
        {
            string pieza = viga.Substring(i, 1);

            if (pieza == "=")
            {
                secuencia++;
            }
            else 
            {
                int pesoSecuencia = (secuencia * (secuencia + 1)) / 2;
               
                pesoTotal += pesoSecuencia * 2;
                secuencia = 0;
            }
        }
        
        if (secuencia > 0)
        {
            pesoTotal += (secuencia * (secuencia + 1)) / 2;
        }

        int pesoBase = 0;
        switch (baseViga)
        {
            case "%":
                pesoBase = 10;
                break;
            case "&":
                pesoBase = 30;
                break;
            case "#":
                pesoBase = 90;
                break;
        }

        return pesoBase >= pesoTotal;
    }
}
