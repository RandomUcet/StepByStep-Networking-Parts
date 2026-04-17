using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Veselé_Vánoce
{
    internal class Program
    {
        private static object random;

        static void Main(string[] args)
        {
            Random random = new Random();
            //VeseleVanoce();

            start:
            Console.Title = "Veselé Vánoce";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Veselé Vánoce");
            Console.WriteLine("");
            Console.WriteLine("Vyberte si velikost stromku");
            int velikostStromku = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            if (velikostStromku % 2 == 0)
                velikostStromku++;
            if (velikostStromku <= 10)
            {
                Console.WriteLine("Zadána malá velikost, zadejte ji prosím znovu");
                Thread.Sleep(5000);
                Console.Clear();
                goto start;
            }    

            int stred = velikostStromku / 2;
            int mezi = 0;
            string[,] pole = new string[velikostStromku, (velikostStromku / 2) + 6];
            
            for (int i = 0; i < velikostStromku; i++)
            {
                for (int j = 0; j < velikostStromku; j++)
                {
                    if (stred - mezi <= j && j <= stred + mezi && i < velikostStromku / 2 && i == 0)
                        pole[j, i] = "*";
                    else if (stred - mezi <= j && j <= stred + mezi && i < velikostStromku / 2 && i != 0)
                    {
                        if (random.Next(1000) % 13 == 0)
                            pole[i, j] = "%";
                        else
                            pole[i, j] = "#";
                    }
                    else if (i > 2 - velikostStromku / 2 && stred - 1 <= j && j <= stred + 1 && i != 0)
                        pole[i, j] = "0";
                    else
                        pole[j, i] = "";

                }
                mezi++;
            }
            Console.ReadLine();
        }
    }
}
