using LlibreriaJoc;
using ClassesCreacioPersonatges
using System;

namespace JocHerois
{
    public class Codi
    {
        public static void Main()
        {
            //VARIABLES

            int attempts = 3;
            string option, characterNames;

            //CONSTANTS

            const int MaxAttempts = 3;
            string[] startMenuOptions = { "a", "b" };
            string[] invalidCharacters = { " ", ".", ";", ":", "-", "_",
                                           "!", "¡", "?", "¿", "(", ")",
                                           "[", "]", "{", "}", "'", "\"",
                                           "·", "$", "%", "&", "/", "=",
                                           "+", "*", "ª", "º", "<", ">",
                                           "¬", "¨", "´", "`", "€", "£" };

            //MISSATGES

            const string MsgTitle = "         BENVINGUT/DA A\n" +
                                    "*********************************\n" +
                                    "        HEROIS VS MONSTRE\n" +
                                    "*********************************\n";
            const string MsgChooseOption = "Què vols fer? (Intents restants: {0}) \na. Partida Nova \nb. Sortir";
            const string MsgInputCharacterNames = "Introdueix els noms dels personatges (nom,nom,nom,nom): ";

            //PROGRAMA

            Console.WriteLine(MsgTitle);

            do
            {
                Console.WriteLine(MsgChooseOption, attempts);
                option = Console.ReadLine().ToLower();
                if (!GlobalMethods.ValidateOption(option, startMenuOptions))
                {
                    attempts--;
                }
            } while (!GlobalMethods.ValidateOption(option, startMenuOptions) && GlobalMethods.ValidateAttempts(attempts));

            if (GlobalMethods.ValidateAttempts(attempts))
            {
                attempts = MaxAttempts;
                do
                {
                    Console.WriteLine(MsgInputCharacterNames, attempts);
                    characterNames = Console.ReadLine();
                    if (!CharacterCreation.ValidateNameFormat(characterNames, invalidCharacters))
                    {
                        attempts--;
                    }
                } while (!CharacterCreation.ValidateNameFormat(option, invalidCharacters) && GlobalMethods.ValidateAttempts(attempts));
            }
        }
    }
}