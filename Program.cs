using System;
using System.IO;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String line;
            try
            {
                List<List<List<string>>> lstMatrices = new List<List<List<string>>>();
                List<List<string>> lstLista3C = new List<List<string>>();
                List<List<string>> lstMatrix = new List<List<string>>();

                List<string> lineas = File.ReadAllLines("C:\\temp\\Sample.txt").ToList();

                int cnt = 0;
                int bubble = 0;
                int longNumCuenta = lineas[0].Length / 3;

                foreach (var item in lineas)
                {
                    bubble++;

                    if (bubble < 4)
                    {
                        List<string> listaCaracteres = new List<string>();

                        for (int i = 0; i < item.Length; i++)
                        {
                            listaCaracteres.Add(item[i].ToString());

                            if (listaCaracteres.Count == 3)
                            {
                                lstLista3C.Add(listaCaracteres);
                                listaCaracteres = new List<string>();
                            }
                        }
                    }
                    else
                    {
                        bubble = 0;
                    }
                }

                int contr = 0;

                for (int i = 0; i < lstLista3C.Count - (longNumCuenta * 2); i++) 
                {
                    if (contr == longNumCuenta)
                    {
                        contr = 0;
                        i = i + (longNumCuenta * 2);
                    }
                    lstMatrix.Add(lstLista3C[i]);
                    lstMatrix.Add(lstLista3C[i + (longNumCuenta)]);
                    lstMatrix.Add(lstLista3C[i + (longNumCuenta * 2)]);

                    lstMatrices.Add(lstMatrix);
                    contr++;
                    lstMatrix = new List<List<string>>();
                }

                List<string> numerosFinales = new List<string>();
                String numFinal = "";

                foreach (var item in lstMatrices)
                {
                    string bajo = "_";
                    string pipe = "|";

                    int numBajos = item[0].Count(x => bajo.Contains(x)) + item[1].Count(x => bajo.Contains(x)) + item[2].Count(x => bajo.Contains(x));
                    int numPipes = item[0].Count(x => pipe.Contains(x)) + item[1].Count(x => pipe.Contains(x)) + item[2].Count(x => pipe.Contains(x));

                    int totalC = numPipes + numBajos;

                    switch (totalC)
                    {
                        case 2:
                            if (item[1][2].Equals("|") && item[2][2].Equals("|"))
                            {
                                numFinal += "1";
                            }
                            else
                            {
                                numFinal += "?";
                            }
                            break;
                        case 3:
                            if (item[1][2].Equals("|") && item[2][2].Equals("|") && item[0][1].Equals("_"))
                            {
                                numFinal += "7";
                            }
                            else
                            {
                                numFinal += "?";
                            }
                            break;
                        case 4:
                            if (item[1][0].Equals("|") && item[1][1].Equals("_") && item[1][2].Equals("|") && item[2][2].Equals("|"))
                            {
                                numFinal += "4";
                            }
                            else
                            {
                                numFinal += "?";
                            }
                            break;
                        case 5:
                            if (item[0][1].Equals("_") && item[1][1].Equals("_") && item[2][1].Equals("_"))
                            {
                                if (item[0][0].Equals(" ") && item[0][2].Equals(" "))
                                {
                                    if (item[1][2].Equals("|") && item[2][2].Equals("|"))
                                    {
                                        numFinal += "3";
                                    }
                                    else if (item[1][0].Equals("|") && item[2][2].Equals("|"))
                                    {
                                        numFinal += "5";
                                    }
                                    else
                                    {
                                        numFinal += "2";
                                    }
                                }
                                else
                                {
                                    numFinal += "?";
                                }
                            }
                            else
                            {
                                numFinal += "?";
                            }
                            break;
                        case 6:
                            if (numPipes == 4)
                            {
                                if (item[0][1].Equals("_") && item[2][1].Equals("_"))
                                {
                                    if (item[0][0].Equals(" ") && item[0][2].Equals(" "))
                                    {
                                        numFinal += "0";
                                    }
                                    else
                                    {
                                        numFinal += "?";
                                    }
                                }
                                else
                                {
                                    numFinal += "?";
                                }
                            }
                            else
                            {
                                if (item[0][1].Equals("_") && item[1][1].Equals("_") && item[2][1].Equals("_"))
                                {
                                    if (item[0][0].Equals(" ") && item[0][2].Equals(" "))
                                    {
                                        if (item[2][0].Equals("|"))
                                        {
                                            numFinal += "6";
                                        }
                                        else
                                        {
                                            numFinal += "9";
                                        }
                                    }
                                    else
                                    {
                                        numFinal += "?";
                                    }
                                }
                                else
                                {
                                    numFinal += "?";
                                }
                            }
                            break;
                        case 7:
                            if (item[0][1].Equals("_") && item[1][1].Equals("_") && item[2][1].Equals("_"))
                            {
                                if (item[0][0].Equals(" ") && item[0][2].Equals(" "))
                                {
                                    numFinal += "8";
                                }
                                else
                                {
                                    numFinal += "?";
                                }
                            }
                            else
                            {
                                numFinal += "?";
                            }
                            break;
                        default:
                            numFinal += "?";
                            break;
                    }

                    if (numFinal.Length == longNumCuenta)
                    {
                        numerosFinales.Add(numFinal);
                        numFinal = "";
                    }
                }

                foreach (string item in numerosFinales)
                {
                    if (!item.Contains('?'))
                    {
                        int suma = 0;

                        for (int i = 0; i < item.Length; i++)
                        {
                            suma += (Int32.Parse(item[i].ToString()) * Int32.Parse((item.Length - i).ToString()));
                        }

                        if (suma % 11 == 0)
                        {
                            Console.WriteLine(item + " OK");
                        }
                        else
                        {
                            Console.WriteLine(item + " ERR");
                        }
                    }
                    else
                    {
                        Console.WriteLine(item + " ILL");
                    }
                }

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }

    public class MatrizNumero
    {

    }
}