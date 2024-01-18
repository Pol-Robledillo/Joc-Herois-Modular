using LlibreriaJoc;
using System;

namespace JocHerois
{
    public class Codi
    {
        public static void Main()
        {
            //VARIABLES

            string[] startMenuOptions = { "a", "b" };
            int attempts = 3;
            string option;

            //CONSTANTS



            //MISSATGES

            const string MsgTitle = "         BENVINGUT/DA A\n" +
                                    "*********************************\n" +
                                    "        HEROIS VS MONSTRE\n" +
                                    "*********************************";
            const string MsgChooseOption = "Què vols fer? (Intents restants: {0}) \na. Partida Nova \nb. Sortir";
            const string MsgError = "Valor invàlid. Intents restants: {0}";

            Console.WriteLine(MsgTitle);
            do
            {
                Console.WriteLine(MsgChooseOption, attempts);
                option = Console.ReadLine().ToLower();
                attempts--;
            } while (!GlobalMethods.ValidateOption(option, startMenuOptions) && GlobalMethods.ValidateAttempts(attempts));
        }
    }
}