namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zde parametry dle kterých budeme pokračovat");
            int[] poleCisel = NactiCisla(0); //Pokud chceme ukončovat číslem 
            //int[] poleCisel = NactiCisla("Konec"); // Pokud cheme ukončovat řetězcem
            int[] minMaxS = MinMax(0, poleCisel); int[] minMaxL = MinMax(1,poleCisel); //Získání minMax jak pro sudá tak pro lichá čísla 
            Console.WriteLine("S | L");
            Console.WriteLine("MAX: "+ minMaxS[0] + " | " + minMaxL[0]);
            Console.WriteLine("MIN: "+ minMaxS[1] + " | " + minMaxL[1]);
        }
        private static int[] NactiCisla(int UkoncovaciCislo) //Ukončení podle námi zvoleného čísla
        {
            int[] poleCisel = new int[20]; //Zatím pro nás nejjednoduší co si vytvořít větší pole než je třeba a nemusíme vyuižít jeho celou velikost
            int cislo = 0;
            for (int i = 0; i < poleCisel.Length; i++) 
            {
                cislo = Convert.ToInt32(Console.ReadLine());
                if (cislo == UkoncovaciCislo) //Ukončení proběhne pokud vložíme hodnotu UkoncovacihoCisla u mě v ukázce to je 0
                    break;
                poleCisel[i] = cislo;
            }
            return poleCisel;
        }
        private static int[] NactiCisla(string UkoncovaciRetezc) //Ukončení podle námi zvoleného Cislou nebo textu
        {
            int[] poleCisel = new int[20]; //Zatím pro nás nejjednoduší co si vytvořít větší pole než je třeba a nemusíme vyuižít jeho celou velikost
            string text = "Ahoj";
            for (int i = 0; i < poleCisel.Length; i++) 
            {
                text = Console.ReadLine();
                if (text == UkoncovaciRetezc) //Ukončení proběhne pokud vložíme hodnotu UkoncovaciRetezce u mě v ukázce je to 0
                    break;
                poleCisel[i] = Convert.ToInt32(text);
            }
            return poleCisel;
        }
        private static int[] MinMax(int zbytek, int[] sadaCisel) //Metoda která dokáže najít minMax jak pro lichá tak i pro sudá
        {
            int[] minMax = { int.MinValue, int.MaxValue }; 
            for(int i = 0; i<sadaCisel.Length && sadaCisel[i] !=0;i++) // sloýená podmínka se používá kvůli tomu aby nemusely procházet celé pole protože pole po vytvoření je plné nul
            {
                if (sadaCisel[i] % 2 == zbytek)
                {
                    if (minMax[0] < sadaCisel[i])
                        minMax[0] = sadaCisel[i];
                    if (minMax[1] > sadaCisel[i])
                        minMax[1] = sadaCisel[i];
                }
            }
            return minMax;
        }
    }
}