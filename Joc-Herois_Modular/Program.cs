﻿using LlibreriaJoc;
using ClassesCreacioPersonatges;
using System;

namespace JocHerois
{
    public class Codi
    {
        public static void Main()
        {
            //CONSTANTS

            const int Characters = 4, StatTypes = 4, MaxAttempts = 3, Archer = 0, Barbarian = 1, Mage = 2, Druid = 3, HP = 0, ATK = 1, DEF = 2, SkillCD = 3, MaxSkillCD = 5;
            int[] MonsterMinStats = { 7000, 300, 20 };
            int[] MonsterMaxStats = { 10000, 400, 30 };
            int[,] MinStats = { { 1500, 200, 25, 0 },
                                { 3000, 150, 35, 0 },
                                { 1100, 300, 20, 0 },
                                { 2000, 70, 25, 0 } };
            int[,] MaxStats = { { 2000, 300, 35, 0 },
                                { 3750, 250, 45, 0 },
                                { 1500, 400, 35, 0 },
                                { 2500, 120, 40, 0 } };
            string[] startMenuOptions = { "a", "b" };
            string[] invalidCharacters = { " ", ".", ";", ":", "-", "_",
                                           "!", "¡", "?", "¿", "(", ")",
                                           "[", "]", "{", "}", "'", "\"",
                                           "·", "$", "%", "&", "/", "=",
                                           "+", "*", "ª", "º", "<", ">",
                                           "¬", "¨", "´", "`", "€", "£" };
            string[] difficultyMenuOptions = { "a", "b", "c", "d" };

            //MISSATGES
            const string ArcherMSG = "Arquer";
            const string BarbarianMSG = "Bàrbar";
            const string MageMSG = "Mag";
            const string DruidMSG = "Druida";
            const string MonsterMSG = "Monstre";
            const string HPMSG = "vida";
            const string ATKMSG = "atac";
            const string DEFMSG = "defensa";
            const string MsgPressEnter = "Prem [Enter] per continuar...";
            const string MsgTitle = "         BENVINGUT/DA A\n" +
                                    "*********************************\n" +
                                    "        HEROIS VS MONSTRE\n" +
                                    "*********************************\n";
            const string MsgChooseOption = "Què vols fer? (Intents restants: {0}) \na. Partida Nova \nb. Sortir";
            const string MsgInputCharacterNames = "Introdueix els noms dels personatges, no poden contenir caràcters especials (Ex. nom,nom,nom,nom): ";
            const string MsgChooseDifficulty = "Escull la dificultat (Intents restants: {0}): " +
                                             "\na. Fàcil (Max. stats herois, Min. stats monstre) " +
                                             "\nb. Difícil (Min. stats herois, Max. stats monstre) " +
                                             "\nc. Personalitzat (Escull les stats del herois i del monstre) " +
                                             "\nd. Aleatori (S'assignen stats aleatòries)";
            const string MsgEasyDifficulty = "Has escollit la dificultat fàcil. Se li han assignat les stats màximes als herois i les mínimes al monstre.";
            const string MsgHardDifficulty = "Has escollit la dificultat difícil. Se li han assignat les stats mínimes als herois i les màximes al monstre.";
            const string MsgInputCharacterStats = "Introdueix la stat {0} de {1} [{2} - {3}] (Intents restants: {4}): ";
            const string MsgMinStat = "Has superat el límit d'intents per aquesta stat, se li assignarà el valor mínim: {0}.";
            const string MsgMaxStat = "Has superat el límit d'intents per aquesta stat, se li assignarà el valor màxim: {0}.";
            const string MsgCharacterStats = "Les stats dels herois són: \nNom\tVida\tAtac\tDefensa";
            const string MsgShowCharacterStats = "{0}\t{1}\t{2}\t{3}";
            const string MsgMonsterStats = "Les stats del monstre són: \nVida\tAtac\tDefensa";
            const string MsgShowMonsterStats = "{0}\t{1}\t{2}";
            const string MsgMaxAttempts = "Has superat el límit d'intents";
            const string MsgGameExit = "Gràcies per jugar! Fins aviat!";

            //VARIABLES

            int attempts = 3;
            int[] monsterStats = new int[3];
            int[,] characterStats = new int[Characters, StatTypes];
            string option, characterNames, difficulty, characterMSG = "", statMSG = "";
            string[] characterNamesList = new string[Characters];

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
                    Console.Clear();
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
                    characterNamesList = CharacterCreation.AssignCharacterNames(characterNames);
                    for (int i = 0; i < characterNamesList.Length; i++)
                    {
                        characterMSG = CharacterCreation.AssignNameMessage(i, ArcherMSG, BarbarianMSG, MageMSG, DruidMSG);
                        Console.WriteLine("{0}: {1}", characterMSG, characterNamesList[i]);
                    }
                    Console.WriteLine(MsgPressEnter);
                    Console.ReadLine();
                    if (GlobalMethods.ValidateAttempts(attempts))
                    {
                        Console.Clear();
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
                        if (GlobalMethods.ValidateAttempts(attempts))
                        {
                            Console.Clear();
                            switch (difficulty)
                            {
                                case "a":
                                    //FÀCIL
                                    characterStats = CharacterCreation.AssignStats(characterStats, MaxStats, Characters, StatTypes);
                                    monsterStats = CharacterCreation.AssignStats(monsterStats, MonsterMinStats);
                                    Console.WriteLine(MsgEasyDifficulty);
                                    break;
                                case "b":
                                    //DIFÍCIL
                                    characterStats = CharacterCreation.AssignStats(characterStats, MinStats, Characters, StatTypes);
                                    monsterStats = CharacterCreation.AssignStats(monsterStats, MonsterMaxStats);
                                    Console.WriteLine(MsgHardDifficulty);
                                    break;
                                case "c":
                                    //PERSONALITZAT
                                    for (int i = 0; i < Characters; i++)
                                    {
                                        characterMSG = CharacterCreation.AssignNameMessage(i, ArcherMSG, BarbarianMSG, MageMSG, DruidMSG);
                                        for (int j = 0; j < StatTypes - 1; j++)
                                        {
                                            attempts = MaxAttempts;
                                            statMSG = CharacterCreation.AssignStatMessage(j, HPMSG, ATKMSG, DEFMSG);
                                            do
                                            {
                                                Console.WriteLine(MsgInputCharacterStats, statMSG, characterMSG, MinStats[i, j], MaxStats[i, j], attempts);
                                                characterStats[i, j] = Convert.ToInt32(Console.ReadLine());
                                                Console.WriteLine();
                                                if (!CharacterCreation.ValidateStatRange(characterStats[i, j], MinStats[i, j], MaxStats[i, j]))
                                                {
                                                    attempts--;
                                                }
                                            } while (!CharacterCreation.ValidateStatRange(characterStats[i, j], MinStats[i, j], MaxStats[i, j]) && GlobalMethods.ValidateAttempts(attempts));
                                            if (!GlobalMethods.ValidateAttempts(attempts))
                                            {
                                                Console.WriteLine(MsgMinStat, MinStats[i, j]);
                                                characterStats[i, j] = MinStats[i, j];
                                            }
                                        }
                                        Console.WriteLine();
                                    }
                                    for (int i = 0; i < Characters; i++)
                                    {
                                        characterStats[i, SkillCD] = MaxSkillCD;
                                    }
                                    for (int i = 0; i < monsterStats.Length; i++)
                                    {
                                        attempts = MaxAttempts;
                                        characterMSG = MonsterMSG;
                                        statMSG = CharacterCreation.AssignStatMessage(i, HPMSG, ATKMSG, DEFMSG);

                                        do
                                        {
                                            Console.WriteLine(MsgInputCharacterStats, statMSG, characterMSG, MonsterMinStats[i], MonsterMaxStats[i], attempts);
                                            monsterStats[i] = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine();
                                            if (!CharacterCreation.ValidateStatRange(monsterStats[i], MonsterMinStats[i], MonsterMaxStats[i]))
                                            {
                                                attempts--;
                                            }
                                        } while (!CharacterCreation.ValidateStatRange(monsterStats[i], MonsterMinStats[i], MonsterMaxStats[i]) && GlobalMethods.ValidateAttempts(attempts));
                                        if (!GlobalMethods.ValidateAttempts(attempts))
                                        {
                                            Console.WriteLine(MsgMaxStat, MonsterMaxStats[i]);
                                            monsterStats[i] = MonsterMaxStats[i];
                                        }
                                    }
                                    break;
                                case "d":
                                    //ALEATORI
                                    characterStats = CharacterCreation.AssignStats(characterStats, MinStats, MaxStats, Characters, StatTypes);
                                    monsterStats = CharacterCreation.AssignStats(monsterStats, MonsterMinStats, MonsterMaxStats);
                                    break;
                            }
                            Console.WriteLine(MsgCharacterStats);
                            for (int i = 0; i < Characters; i++)
                            {
                                Console.WriteLine(MsgShowCharacterStats, characterNamesList[i], characterStats[i, HP], characterStats[i, ATK], characterStats[i, DEF]);
                            }
                            Console.WriteLine();
                            Console.WriteLine(MsgMonsterStats);
                            Console.WriteLine(MsgShowMonsterStats, monsterStats[HP], monsterStats[ATK], monsterStats[DEF]);
                            Console.WriteLine();
                            Console.WriteLine(MsgPressEnter);
                            Console.ReadLine();
                        }
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