﻿using LlibreriaJoc;
using ClassesCreacioPersonatges;
using System;

namespace JocHerois
{
    public class Codi
    {
        public static void Main()
        {
            //VARIABLES

            int attempts = 3;
            string option, characterNames, difficulty;
            string[] characterNamesList = new string[4];

            //CONSTANTS

            const int MaxAttempts = 3;
            string[] startMenuOptions = { "a", "b" };
            string[] invalidCharacters = { " ", ".", ";", ":", "-", "_",
                                           "!", "¡", "?", "¿", "(", ")",
                                           "[", "]", "{", "}", "'", "\"",
                                           "·", "$", "%", "&", "/", "=",
                                           "+", "*", "ª", "º", "<", ">",
                                           "¬", "¨", "´", "`", "€", "£" };
            string[] difficultyMenuOptions = { "a", "b", "c", "d" };

            //MISSATGES

            const string MsgTitle = "         BENVINGUT/DA A\n" +
                                    "*********************************\n" +
                                    "        HEROIS VS MONSTRE\n" +
                                    "*********************************\n";
            const string MsgChooseOption = "Què vols fer? (Intents restants: {0}) \na. Partida Nova \nb. Sortir";
            const string MsgInputCharacterNames = "Introdueix els noms dels personatges, no poden contenir caràcters especials (Ex. nom,nom,nom,nom): ";

            const string MsgMaxAttempts = "Has superat el límit d'intents";
            const string MsgGameExit = "Gràcies per jugar! Fins aviat!";
            const string MsgChooseDifficulty = "Escull la dificultat (Intents restants: {0}): \na. Fàcil (Max. stats herois, Min. stats monstre) \nb. Difícil (Min. stats herois, Max. stats monstre) \nc. Personalitzat (Escull les stats del herois i del monstre) \nd. Aleatori (S'assignen stats aleatòries)";

            //PROGRAMA

            do
            {
                Console.WriteLine(MsgTitle);
                do
                {
                    //ELECCIÓ OPCIÓ MENÚ PRINCIPAL
                    Console.WriteLine(MsgChooseOption, attempts);
                    option = Console.ReadLine().ToLower();
                    Console.WriteLine();
                    if (!GlobalMethods.ValidateOption(option, startMenuOptions))
                    {
                        attempts--;
                    }
                } while (!GlobalMethods.ValidateOption(option, startMenuOptions) && GlobalMethods.ValidateAttempts(attempts));

                if (GlobalMethods.ValidateAttempts(attempts) && !GlobalMethods.CheckProgramEnd(option))
                {
                    attempts = MaxAttempts;
                    do
                    {
                        //INTRODUCCIÓ NOMS PERSONATGES
                        Console.WriteLine(MsgInputCharacterNames, attempts);
                        characterNames = Console.ReadLine();
                        Console.WriteLine();
                        if (!CharacterCreation.ValidateNameFormat(characterNames, invalidCharacters))
                        {
                            attempts--;
                        }
                    } while (!CharacterCreation.ValidateNameFormat(characterNames, invalidCharacters) && GlobalMethods.ValidateAttempts(attempts));
                    if (GlobalMethods.ValidateAttempts(attempts))
                    {
                        attempts = MaxAttempts;

                        characterNamesList = CharacterCreation.AssignCharacterNames(characterNames);

                        do
                        {
                            //ELECCIÓ OPCIÓ MENÚ DIFICULTAT
                            Console.WriteLine(MsgChooseDifficulty, attempts);
                            difficulty = Console.ReadLine().ToLower();
                            Console.WriteLine();
                            if (!GlobalMethods.ValidateOption(difficulty, difficultyMenuOptions))
                            {
                                attempts--;
                            }
                        } while (!GlobalMethods.ValidateOption(difficulty, difficultyMenuOptions) && GlobalMethods.ValidateAttempts(attempts));

                    }
                }
                if (!GlobalMethods.ValidateAttempts(attempts))
                {
                    Console.WriteLine(MsgMaxAttempts);
                }
            } while (!GlobalMethods.CheckProgramEnd(option) && GlobalMethods.ValidateAttempts(attempts));
            Console.WriteLine(MsgGameExit);
        }
    }
}