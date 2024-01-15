using LlibreriaJoc;
using System;

namespace JocHerois
{
    public class Codi
    {
        public static void Main()
        {
            int attempts = 3;
            string option;
            const string MsgTitle = "         BENVINGUT/DA A\n" +
                                    "*********************************\n" +
                                    "        HEROIS VS MONSTRE\n" +
                                    "*********************************";
            const string MsgChooseOption = "Què vols fer? \na. Partida Nova \nb. Sortir";
            const string MsgError = "Valor invàlid. Intents restants: {0}";

            Console.WriteLine(MsgTitle);
            Console.WriteLine(MsgChooseOption);
            do
            {
                option = Console.ReadLine().ToLower();
                attempts--;
            } while (GlobalMethods.ValidateStartOption(option, MsgError, attempts));
        }
    }
}