using LlibreriaJoc;
using ClassesCreacioPersonatges;
using CombatMethods;
using System;

namespace JocHerois
{
    public class Codi
    {
        public static void Main()
        {
            //CONSTANTS

            const int Characters = 4, StatTypes = 4, MaxAttempts = 3, Archer = 0, Barbarian = 1, Mage = 2, Druid = 3, HP = 0, ATK = 1, DEF = 2, SkillCD = 3, MaxSkillCD = 5, MissProb = 5, CritRate = 10;
            int[] MonsterMinStats = { 7000, 300, 20 };
            int[] MonsterMaxStats = { 10000, 400, 30 };
            int[,] MinStats = { { 1500, 200, 25, 0 },
                                { 3000, 150, 35, 0 },
                                { 1100, 300, 20, 0 },
                                { 2000, 100, 25, 0 } };
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
            string[] actionMenuOptions = { "a", "b", "c" };
            string[] skills = { "Noqueja el monstre 2 torns",
                                "Augmenta la seva defensa al 100% durant 3 torns",
                                "Dispara una bola de foc que fa 3 cops el seu atac",
                                "Cura 500 de vida a tots els herois vius" };

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
            const string MsgShowMonsterHP = "Vida del monstre: {0}";
            const string MsgRound = "RONDA {0}";
            const string MsgSelectAction = "Torn de {0}! \nSelecciona l'acció: ({1} intents restants)\na. Atacar \nb. Protegir-se (Defensa x2) \nc. Habilitat especial (5 torns de CD): {2}";
            const string MsgMissedAtack = "{0} ha fallat l'atac!";
            const string MsgAttack = "{0} ataca a {1} amb {2} d'atac. {1} es defensa i només rep {3} de dany. Vida restant de {1}: {4}.";
            const string MsgCritAttack = "Atac crític! {0} ataca a {1} amb {2} d'atac. {1} es defensa i només rep {3} de dany. Vida restant de {1}: {4}.";
            const string MsgCharacterDefends = "{0} augmenta la seva defensa al doble durant aquesta ronda.";
            const string MsgArcherSkill = "El monstre està atordit durant 2 torns.";
            const string MsgBarbarianSkill = "La defensa de {0} s'ha augmentat al 100% durant 3 torns.";
            const string MsgMageSkill = "{0} li llença una bola de foc al monstre.";
            const string MsgDruidSkill = "{0} ha curat 500 de vida a tots els herois vius.";
            const string MsgMonsterStunned = "El monstre està atordit i no pot atacar.";
            const string MsgCharacterDead = "{0} ha mort.";
            const string MsgYouWin = "Has guanyat!";
            const string MsgYouLose = "Has perdut!";
            const string MsgSkipTurn = "S'ha saltat el torn.";
            const string MsgMaxAttempts = "Has superat el límit d'intents. ";
            const string MsgGameExit = "Gràcies per jugar! Fins aviat!";

            //VARIABLES

            bool[] charactersDefending = { false, false, false, false };
            double totalHP, currentHPMonster, atkDamage;
            double[] currentHP = new double[Characters];
            int count, attempts = 3, round = 1, tornPersonatge, monsterStunned = 0, barbarianSkill = 0, charactersAlive = 4, prevCharsAlive = charactersAlive;
            int[] characterNums = { 0, 1, 2, 3 };
            int[] ThreeCharactersAlive = new int[3];
            int[] TwoCharactersAlive = new int[2];
            int[] OneCharacterAlive = new int[1];
            int[] monsterStats = new int[3];
            int[,] characterStats = new int[Characters, StatTypes];
            string startOption, option, characterNames, difficulty, characterMSG, statMSG;
            string[] characterNamesList = new string[Characters];

            //PROGRAMA

            do
            {
                Console.Clear();
                Console.WriteLine(MsgTitle);
                do
                {
                    //ELECCIÓ OPCIÓ MENÚ PRINCIPAL
                    Console.WriteLine(MsgChooseOption, attempts);
                    startOption = Console.ReadLine().ToLower();
                    Console.WriteLine();
                    if (!GlobalMethods.ValidateOption(startOption, startMenuOptions))
                    {
                        attempts--;
                    }
                } while (!GlobalMethods.ValidateOption(startOption, startMenuOptions) && GlobalMethods.ValidateAttempts(attempts));

                if (GlobalMethods.ValidateAttempts(attempts) && !GlobalMethods.CheckProgramEnd(startOption))
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
                                        characterStats[i, SkillCD] = 0;
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
                            currentHP = CharacterCreation.AssignCurrentHP(currentHP, characterStats, HP);
                            currentHPMonster = CharacterCreation.AssignCurrentHP(monsterStats, HP);

                            //COMBAT
                            do
                            {
                                for (int i = 0; i < charactersAlive; i++)
                                {
                                    Console.Clear();
                                    Console.WriteLine(MsgRound, round);
                                    Combat.ShowHP(currentHP, characterNamesList);
                                    Console.WriteLine();
                                    Console.WriteLine(MsgShowMonsterHP, currentHPMonster);
                                    Console.WriteLine();
                                    attempts = MaxAttempts;
                                    prevCharsAlive = charactersAlive;

                                    switch (charactersAlive)
                                    {
                                        default:
                                            tornPersonatge = characterNums[GlobalMethods.GenerateRandom(characterNums.Length - i)];
                                            characterNums = Combat.ArrangeNumsList(characterNums, tornPersonatge, characterNums.Length - (i + 1));
                                            break;
                                        case 3:
                                            tornPersonatge = ThreeCharactersAlive[GlobalMethods.GenerateRandom(ThreeCharactersAlive.Length - i)];
                                            ThreeCharactersAlive = Combat.ArrangeNumsList(ThreeCharactersAlive, tornPersonatge, ThreeCharactersAlive.Length - (i + 1));
                                            break;
                                        case 2:
                                            tornPersonatge = TwoCharactersAlive[GlobalMethods.GenerateRandom(TwoCharactersAlive.Length - i)];
                                            TwoCharactersAlive = Combat.ArrangeNumsList(TwoCharactersAlive, tornPersonatge, TwoCharactersAlive.Length - (i + 1));
                                            break;
                                        case 1:
                                            tornPersonatge = OneCharacterAlive[GlobalMethods.GenerateRandom(OneCharacterAlive.Length)];
                                            break;
                                    }

                                    do
                                    {
                                        //ELECCIÓ OPCIÓ MENÚ ACCIONS
                                        Console.WriteLine(MsgSelectAction, characterNamesList[tornPersonatge], attempts, skills[tornPersonatge]);
                                        option = Console.ReadLine().ToLower();
                                        Console.WriteLine();
                                        if (!GlobalMethods.ValidateOption(option, actionMenuOptions) || Combat.ValidateSkillCD(option, characterStats[tornPersonatge, SkillCD]))
                                        {
                                            attempts--;
                                        }
                                    } while ((!GlobalMethods.ValidateOption(option, actionMenuOptions) || Combat.ValidateSkillCD(option, characterStats[tornPersonatge, SkillCD])) && GlobalMethods.ValidateAttempts(attempts));
                                    if (!GlobalMethods.ValidateAttempts(attempts))
                                    {
                                        Console.WriteLine(MsgMaxAttempts + MsgSkipTurn);
                                    }
                                    else
                                    {
                                        switch (option)
                                        {
                                            case "a":
                                                //ATACAR
                                                if (Combat.CalcProbability(MissProb))
                                                {
                                                    Console.WriteLine(MsgMissedAtack, characterNamesList[tornPersonatge]);
                                                }
                                                else
                                                {
                                                    atkDamage = Combat.Attack(characterStats[tornPersonatge, ATK], monsterStats[DEF]);
                                                    if (Combat.CalcProbability(CritRate))
                                                    {
                                                        atkDamage *= 2;
                                                        currentHPMonster -= atkDamage;
                                                        if (currentHPMonster < 0)
                                                        {
                                                            currentHPMonster = 0;
                                                        }
                                                        Console.WriteLine(MsgCritAttack, characterNamesList[tornPersonatge], MonsterMSG, characterStats[tornPersonatge, ATK], atkDamage, currentHPMonster);
                                                    }
                                                    else
                                                    {
                                                        currentHPMonster -= atkDamage;
                                                        if (currentHPMonster < 0)
                                                        {
                                                            currentHPMonster = 0;
                                                        }
                                                        Console.WriteLine(MsgAttack, characterNamesList[tornPersonatge], MonsterMSG, characterStats[tornPersonatge, ATK], atkDamage, currentHPMonster);
                                                    }
                                                }
                                                break;
                                            case "b":
                                                //DEFENSAR
                                                Console.WriteLine(MsgCharacterDefends, characterNamesList[tornPersonatge]);
                                                charactersDefending[tornPersonatge] = true;
                                                break;
                                            case "c":
                                                //HABILITAT ESPECIAL
                                                switch (tornPersonatge)
                                                {
                                                    case Archer:
                                                        Console.WriteLine(MsgArcherSkill);
                                                        monsterStunned = 2;
                                                        break;
                                                    case Barbarian:
                                                        Console.WriteLine(MsgBarbarianSkill, characterNamesList[tornPersonatge]);
                                                        barbarianSkill = 3;
                                                        break;
                                                    case Mage:
                                                        Console.WriteLine(MsgMageSkill, characterNamesList[tornPersonatge]);
                                                        if (Combat.CalcProbability(MissProb))
                                                        {
                                                            Console.WriteLine(MsgMissedAtack, characterNamesList[tornPersonatge]);
                                                        }
                                                        else
                                                        {
                                                            atkDamage = Combat.Attack(characterStats[tornPersonatge, ATK] * 3, monsterStats[DEF]);
                                                            if (Combat.CalcProbability(CritRate))
                                                            {
                                                                atkDamage *= 2;
                                                                currentHPMonster -= atkDamage;
                                                                if (currentHPMonster < 0)
                                                                {
                                                                    currentHPMonster = 0;
                                                                }
                                                                Console.WriteLine(MsgCritAttack, characterNamesList[tornPersonatge], MonsterMSG, characterStats[tornPersonatge, ATK] * 3, atkDamage, currentHPMonster);
                                                            }
                                                            else
                                                            {
                                                                currentHPMonster -= atkDamage;
                                                                if (currentHPMonster < 0)
                                                                {
                                                                    currentHPMonster = 0;
                                                                }
                                                                Console.WriteLine(MsgCritAttack, characterNamesList[tornPersonatge], MonsterMSG, characterStats[tornPersonatge, ATK] * 3, atkDamage, currentHPMonster);
                                                            }
                                                        }
                                                        break;
                                                    case Druid:
                                                        Console.WriteLine(MsgDruidSkill, characterNamesList[tornPersonatge]);
                                                        for (int j = 0; j < Characters; j++)
                                                        {
                                                            if (Combat.ValidateHP(currentHP[j]))
                                                            {
                                                                currentHP[j] += 500;
                                                                if (Combat.ValidateOverHeal(currentHP[j], characterStats[j, HP]))
                                                                {
                                                                    currentHP[j] = characterStats[j, HP];
                                                                }
                                                            }
                                                        }
                                                        break;
                                                }
                                                characterStats[tornPersonatge, SkillCD] = MaxSkillCD;
                                                break;
                                        }
                                        if (!Combat.ValidateHP(currentHPMonster))
                                        {
                                            i = Characters;
                                        }
                                    }
                                    Console.WriteLine(MsgPressEnter);
                                    Console.ReadLine();
                                }
                                Console.Clear();
                                //ATAC MONSTRE
                                if (Combat.ValidateHP(currentHPMonster))
                                {
                                    Console.Clear();
                                    Console.WriteLine(MsgRound, round);
                                    Combat.ShowHP(currentHP, characterNamesList);
                                    Console.WriteLine();
                                    Console.WriteLine(MsgShowMonsterHP, currentHPMonster);
                                    Console.WriteLine();
                                    if (Combat.ValidateStunMonster(monsterStunned))
                                    {
                                        Console.WriteLine(MsgMonsterStunned);
                                        monsterStunned--;
                                    }
                                    else
                                    {
                                        for (int i = 0; i < Characters; i++)
                                        {
                                            if (Combat.ValidateHP(currentHP[i]))
                                            {
                                                if (Combat.CalcProbability(MissProb))
                                                {
                                                    Console.WriteLine(MsgMissedAtack, MonsterMSG);
                                                }
                                                else
                                                {
                                                    if (i == 1 && Combat.ValidateBarbarianSkill(barbarianSkill))
                                                    {
                                                        atkDamage = Combat.Attack(monsterStats[ATK], 100);
                                                        barbarianSkill--;
                                                    }
                                                    else if (charactersDefending[i])
                                                    {
                                                        atkDamage = Combat.Attack(monsterStats[ATK], characterStats[i, DEF] * 2);
                                                    }
                                                    else
                                                    {
                                                        atkDamage = Combat.Attack(monsterStats[ATK], characterStats[i, DEF]);
                                                    }

                                                    if (Combat.CalcProbability(CritRate))
                                                    {
                                                        atkDamage *= 2;
                                                        currentHP[i] -= atkDamage;
                                                        if (currentHP[i] < 0)
                                                        {
                                                            currentHP[i] = 0;
                                                        }
                                                        Console.WriteLine(MsgCritAttack, MonsterMSG, characterNamesList[i], monsterStats[ATK], atkDamage, currentHP[i]);
                                                    }
                                                    else
                                                    {
                                                        currentHP[i] -= atkDamage;
                                                        if (currentHP[i] < 0)
                                                        {
                                                            currentHP[i] = 0;
                                                        }
                                                        Console.WriteLine(MsgAttack, MonsterMSG, characterNamesList[i], monsterStats[ATK], atkDamage, currentHP[i]);
                                                    }
                                                }
                                                if (!Combat.ValidateHP(currentHP[i]))
                                                {
                                                    Console.WriteLine(MsgCharacterDead, characterNamesList[i]);
                                                    charactersAlive--;
                                                }
                                            }
                                        }
                                    }
                                    Console.WriteLine(MsgPressEnter);
                                    Console.ReadLine();
                                }

                                //ACTUALITZACIÓ STATS
                                for (int i = 0; i < Characters; i++)
                                {
                                    if (Combat.ValidateSkillCD(characterStats[i, SkillCD]))
                                    {
                                        characterStats[i, SkillCD]--;
                                    }
                                }
                                for (int i = 0; i < Characters; i++)
                                {
                                    charactersDefending[i] = false;
                                }
                                if (prevCharsAlive != charactersAlive)
                                {
                                    count = 0;
                                    switch (charactersAlive)
                                    {
                                        case 3:
                                            for (int i = 0; i < characterNums.Length && count < 3; i++)
                                            {
                                                if (Combat.ValidateHP(currentHP[characterNums[i]]))
                                                {
                                                    ThreeCharactersAlive[count] = characterNums[i];
                                                    count++;
                                                }
                                            }
                                            break;
                                        case 2:
                                            for (int i = 0; i < characterNums.Length && count < 2; i++)
                                            {
                                                if (Combat.ValidateHP(currentHP[characterNums[i]]))
                                                {
                                                    TwoCharactersAlive[count] = characterNums[i];
                                                    count++;
                                                }
                                            }
                                            break;
                                        case 1:
                                            for (int i = 0; i < characterNums.Length && count < 1; i++)
                                            {
                                                if (Combat.ValidateHP(currentHP[characterNums[i]]))
                                                {
                                                    OneCharacterAlive[count] = characterNums[i];
                                                    count++;
                                                }
                                            }
                                            break;
                                    }
                                }
                                totalHP = CharacterCreation.AssignTotalHP(currentHP);
                                round++;
                            } while (Combat.ValidateHP(totalHP) && Combat.ValidateHP(currentHPMonster));
                            if (Combat.ValidateHP(totalHP))
                            {
                                Console.WriteLine(MsgYouWin);
                            }
                            else
                            {
                                Console.WriteLine(MsgYouLose);
                            }
                            attempts = MaxAttempts;
                            Console.WriteLine(MsgPressEnter);
                            Console.ReadLine();
                            round = 1;
                            monsterStunned = 0;
                            barbarianSkill = 0;
                            charactersAlive = 4;
                            prevCharsAlive = charactersAlive;
                        }
                    }
                }
                if (!GlobalMethods.ValidateAttempts(attempts))
                {
                    Console.WriteLine(MsgMaxAttempts);
                    Console.WriteLine(MsgPressEnter);
                    Console.ReadLine();
                }
            } while (!GlobalMethods.CheckProgramEnd(startOption) && GlobalMethods.ValidateAttempts(attempts));
            Console.WriteLine(MsgGameExit);
        }
    }
}